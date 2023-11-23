import 'package:freezed_annotation/freezed_annotation.dart';
part 'login_response.g.dart';

@JsonSerializable(explicitToJson: true)
class LoginResponse{
  late String token;
  LoginResponse();

  factory LoginResponse.fromJson(Map<String, dynamic> json) => _$LoginResponseFromJson(json);
  Map<String, dynamic> toJson() => _$LoginResponseToJson(this);
}