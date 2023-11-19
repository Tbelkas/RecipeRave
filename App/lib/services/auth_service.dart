import 'package:app/models/requests/network_request.dart';
import 'package:app/models/requests/network_response.dart';
import 'package:app/models/requests/prepared_network_request.dart';
import 'package:app/services/network_service.dart';
import 'package:dio/dio.dart';
import 'package:flutter/foundation.dart';

class AuthService {
  final NetworkService _network_service;

  AuthService() : _network_service = NetworkService(baseUrl: "https://localhost:30000");

  register() {
    Future<NetworkResponse<Model>> execute<Model>(NetworkRequest request,
        Model Function(Map<String, dynamic>) parser, {
          ProgressCallback? onSendProgress,
          ProgressCallback? onReceiveProgress}) async {
      var dio = await _network_service.getDefaultDioClient();
      final req = PreparedNetworkRequest<Model>(
        request,
        parser,
        dio,
        ({...request.headers!}),
        onSendProgress,
        onReceiveProgress,
      );
      final result = await req.executeRequest();

      return result;
    }
  }
}