import 'package:app/models/requests/network_request.dart';
import 'package:app/models/requests/network_response.dart';
import 'package:app/models/requests/prepared_network_request.dart';
import 'package:app/models/responses/base/api_data_response.dart';
import 'package:app/models/responses/base/api_response.dart';
import 'package:dio/dio.dart';

class NetworkService {
  final String baseUrl;
  Map<String, String> _headers;
  NetworkService({required this.baseUrl, httpHeaders}) : _headers = httpHeaders ?? {};

  Future<Dio> getDefaultDioClient() async {
    _headers['content-type'] = 'application/json; charset=utf-8';
    final dio = Dio(BaseOptions(baseUrl: baseUrl, headers: _headers));
    return dio;
  }

  Future<ApiDataResponse> execute<TReq>(NetworkRequest request, {
        ProgressCallback? onSendProgress,
        ProgressCallback? onReceiveProgress}) async {
    var dio = await getDefaultDioClient();
    final req = PreparedNetworkRequest<TReq>(
      request,
      dio,
      ({..._headers, ...(request.headers ?? {})}),
      onSendProgress,
      onReceiveProgress,
    );

    final result = await req.executeDataRequest();
    return result;
  }
}
