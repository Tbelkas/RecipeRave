import 'package:app/models/domain/ingredient_model.dart';
import 'package:app/models/domain/recipe_model.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
part 'likes_recipe_model.g.dart';

@JsonSerializable(explicitToJson: true)
class LikesRecipeModel extends RecipeModel {
  LikesRecipeModel();

  int likeCount = -1;
  bool hasUserLiked = false;
  String createdBy = "";
  DateTime createdDate = DateTime(2023);

  factory LikesRecipeModel.fromJson(Map<String, dynamic> json) => _$LikesRecipeModelFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$LikesRecipeModelToJson(this);
}
