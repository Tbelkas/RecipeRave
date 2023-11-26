import 'package:freezed_annotation/freezed_annotation.dart';
part 'register_model.g.dart';

@JsonSerializable(explicitToJson: true)
class RegisterModel{
  RegisterModel();

  String username = '';
  String email = '';
  String password = '';
  String confirmPassword = '';

  factory RegisterModel.fromJson(Map<String, dynamic> json) => _$RegisterModelFromJson(json);
  Map<String, dynamic> toJson() => _$RegisterModelToJson(this);
}

