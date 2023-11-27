import 'package:app/models/constants/storage_keys.dart';
import 'package:app/models/requests/network_request.dart';
import 'package:app/models/requests/prepared_network_request.dart';
import 'package:app/models/responses/base/api_data_response.dart';
import 'package:dio/dio.dart';
import 'package:get_storage/get_storage.dart';

class NetworkService {
  final String baseUrl;
  final Map<String, String> _headers;
  NetworkService({required this.baseUrl, httpHeaders}) : _headers = httpHeaders ?? {};

  Future<Dio> getDefaultDioClient() async {
    var bearerToken = GetStorage().read(tokenKey);
    if(bearerToken != null){
      _headers['Authorization'] = 'Bearer $bearerToken';
    }

    _headers['content-type'] = 'application/json; charset=utf-8';
    final dio = Dio(BaseOptions(baseUrl: baseUrl, headers: _headers));
    return dio;
  }

  Future<ApiDataResponse> execute(NetworkRequest request, {
        ProgressCallback? onSendProgress,
        ProgressCallback? onReceiveProgress}) async {
    var dio = await getDefaultDioClient();
    final req = PreparedNetworkRequest(
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
