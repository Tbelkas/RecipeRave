import 'package:freezed_annotation/freezed_annotation.dart';

part 'ingredient_model.g.dart';

@JsonSerializable(explicitToJson: true)
class IngredientModel {
  IngredientModel();
  IngredientModel.fromValues(this.name, this.ingredientAmount, this.measurementUnit);

  String name = '';
  double ingredientAmount = 0;
  int measurementUnit = 0;

  factory IngredientModel.fromJson(Map<String, dynamic> json) => _$IngredientModelFromJson(json);
  Map<String, dynamic> toJson() => _$IngredientModelToJson(this);
}
