// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'recipe_browser_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RecipeBrowserModel _$RecipeBrowserModelFromJson(Map<String, dynamic> json) =>
    RecipeBrowserModel()
      ..recipes = (json['recipes'] as List<dynamic>)
          .map((e) => RecipeModel.fromJson(e as Map<String, dynamic>))
          .toList();

Map<String, dynamic> _$RecipeBrowserModelToJson(RecipeBrowserModel instance) =>
    <String, dynamic>{
      'recipes': instance.recipes.map((e) => e.toJson()).toList(),
    };
