// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'recipe_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RecipeModel _$RecipeModelFromJson(Map<String, dynamic> json) => RecipeModel()
  ..id = json['id'] as int
  ..name = json['name'] as String
  ..description = json['description'] as String
  ..ingredients = (json['ingredients'] as List<dynamic>)
      .map((e) => IngredientModel.fromJson(e as Map<String, dynamic>))
      .toList()
  ..base64Image = json['base64Image'] as String?;

Map<String, dynamic> _$RecipeModelToJson(RecipeModel instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
      'ingredients': instance.ingredients.map((e) => e.toJson()).toList(),
      'base64Image': instance.base64Image,
    };
