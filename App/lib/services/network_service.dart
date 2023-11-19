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

}
