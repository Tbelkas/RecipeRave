import 'package:app/models/requests/network_request.dart';
import 'package:app/models/requests/network_response.dart';
import 'package:dio/dio.dart';


class PreparedNetworkRequest<Model> {
  const PreparedNetworkRequest(
      this.request,
      this.parser,
      this.dio,
      this.headers,
      this.onSendProgress,
      this.onReceiveProgress,
      );

  final NetworkRequest request;
  final Model Function(Map<String, dynamic>) parser;
  final Dio dio;
  final Map<String, dynamic> headers;
  final ProgressCallback? onSendProgress;
  final ProgressCallback? onReceiveProgress;


  Future<NetworkResponse<Model>> executeRequest(
      ) async {
    try {
      dynamic body = request.data.whenOrNull(
        json: (data) => data,
        text: (data) => data,
      );
      final response = await dio.request(
        request.path,
        data: body,
        queryParameters: request.queryParams,
        options: Options(
          method: request.type.name,
          headers: headers,
        ),
        onSendProgress: onSendProgress,
        onReceiveProgress: onReceiveProgress,
      );

      return NetworkResponse.ok(parser(response.data));
    } on DioException catch (error) {
      final errorText = error.toString();
      if (error.requestOptions.cancelToken!.isCancelled) {
        return NetworkResponse.noData(errorText);
      }
      switch (error.response?.statusCode) {
        case 400:
          return NetworkResponse.badRequest(errorText);
        case 401:
          return NetworkResponse.noAuth(errorText);
        case 403:
          return NetworkResponse.noAccess(errorText);
        case 404:
          return NetworkResponse.notFound(errorText);
        case 409:
          return NetworkResponse.conflict(errorText);
        default:
          return NetworkResponse.noData(errorText);
      }
    } catch (error) {
      return NetworkResponse.noData(error.toString());
    }
  }

}
