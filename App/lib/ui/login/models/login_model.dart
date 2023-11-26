import 'package:freezed_annotation/freezed_annotation.dart';
part 'login_model.g.dart';

@JsonSerializable(explicitToJson: true)
class LoginModel{
  LoginModel();
  String username = '';
  String password = '';

  factory LoginModel.fromJson(Map<String, dynamic> json) => _$LoginModelFromJson(json);
  Map<String, dynamic> toJson() => _$LoginModelToJson(this);
}