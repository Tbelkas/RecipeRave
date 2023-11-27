import 'package:freezed_annotation/freezed_annotation.dart';
part 'delete_recipe_request.g.dart';
@JsonSerializable(explicitToJson: true)
class DeleteRecipeRequest{
  DeleteRecipeRequest();
  DeleteRecipeRequest.fromValues(this.recipeId);
  int recipeId = -1;

  factory DeleteRecipeRequest.fromJson(Map<String, dynamic> json) => _$DeleteRecipeRequestFromJson(json);
  Map<String, dynamic> toJson() => _$DeleteRecipeRequestToJson(this);
}