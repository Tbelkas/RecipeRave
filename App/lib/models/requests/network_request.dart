import 'package:app/models/requests/network_request_type.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

// https://betterprogramming.pub/building-generic-and-performant-networking-layer-in-flutter-b25c2b1b89a4 <--- this is horrible, but I'm following this after some adaptation
class NetworkRequest<T> {
  const NetworkRequest({
    required this.type,
    required this.path,
    this.data,
    this.queryParams,
    this.headers,
  });

  final NetworkRequestType type;
  final String path;
  final T? data;
  final Map<String, dynamic>? queryParams;
  final Map<String, String>? headers;
}