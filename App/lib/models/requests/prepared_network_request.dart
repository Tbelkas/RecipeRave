import 'dart:convert';

import 'package:app/models/requests/network_request.dart';
import 'package:app/models/responses/base/api_data_response.dart';
import 'package:app/models/responses/base/api_response.dart';
import 'package:dio/dio.dart';

class PreparedNetworkRequest {
  const PreparedNetworkRequest(this.request, this.dio, this.headers, this.onSendProgress, this.onReceiveProgress);

  final NetworkRequest request;
  final Dio dio;
  final Map<String, dynamic> headers;
  final ProgressCallback? onSendProgress;
  final ProgressCallback? onReceiveProgress;

  Future<ApiResponse> executeRequest() async {
    try {
      dynamic body = request.data;
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

      return ApiResponse();
    } on DioException catch (error) {
      var errorResponse = ApiResponse.fromJson(error.response!.data);

      return errorResponse;
    } catch (error) {
      return ApiResponse(errorMessages: ["Something wrong happened"]);
    }
  }

  // todo : singleMethod
  Future<ApiDataResponse> executeDataRequest() async {
    try {
      var body = request.data;
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

      return ApiDataResponse.fromJson(response.data);
    } on DioException catch (error) {
      if(error.response != null){
        var errorResponse = ApiDataResponse.fromJson(error.response!.data);

        return errorResponse;
      }

      return ApiDataResponse(errorMessages: ["Something wrong happened"]);
    } catch (error) {
      // todo: hide error
      return ApiDataResponse(errorMessages: [error.toString()]);
    }
  }
}
