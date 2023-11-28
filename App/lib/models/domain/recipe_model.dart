import 'package:app/models/domain/ingredient_model.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
part 'recipe_model.g.dart';

@JsonSerializable(explicitToJson: true)
class RecipeModel {
  RecipeModel();
  RecipeModel.fromValues(this.name, this.description, this.ingredients, this.base64Image);

  int id = -1;
  String name = '';
  String description = '';
  List<IngredientModel> ingredients = [];
  String? base64Image;

  factory RecipeModel.fromJson(Map<String, dynamic> json) => _$RecipeModelFromJson(json);
  Map<String, dynamic> toJson() => _$RecipeModelToJson(this);
}
