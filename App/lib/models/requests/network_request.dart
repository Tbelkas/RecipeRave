import 'package:app/models/requests/network_request_type.dart';
import 'package:app/models/requests/network_response_body.dart';
// https://betterprogramming.pub/building-generic-and-performant-networking-layer-in-flutter-b25c2b1b89a4

class NetworkRequest {
  const NetworkRequest({
    required this.type,
    required this.path,
    required this.data,
    this.queryParams,
    this.headers,
  });

  final NetworkRequestType type;
  final String path;
  final NetworkRequestBody data;
  final Map<String, dynamic>? queryParams;
  final Map<String, String>? headers;
}