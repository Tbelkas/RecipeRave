import 'package:freezed_annotation/freezed_annotation.dart';
part 'change_like_status_request.g.dart';
@JsonSerializable(explicitToJson: true)
class ChangeLikeStatusRequest{
  ChangeLikeStatusRequest();
  ChangeLikeStatusRequest.fromValues(this.recipeId);
  int recipeId = -1;

  factory ChangeLikeStatusRequest.fromJson(Map<String, dynamic> json) => _$ChangeLikeStatusRequestFromJson(json);
  Map<String, dynamic> toJson() => _$ChangeLikeStatusRequestToJson(this);
}