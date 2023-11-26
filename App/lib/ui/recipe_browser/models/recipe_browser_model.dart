import 'package:app/models/domain/recipe_model.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'recipe_browser_model.g.dart';

@JsonSerializable(explicitToJson: true)
class RecipeBrowserModel {
  RecipeBrowserModel();

  List<RecipeModel> recipes = [];

  factory RecipeBrowserModel.fromJson(Map<String, dynamic> json) => _$RecipeBrowserModelFromJson(json);
  Map<String, dynamic> toJson() => _$RecipeBrowserModelToJson(this);
}
