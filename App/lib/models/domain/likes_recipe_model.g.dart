// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'likes_recipe_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LikesRecipeModel _$LikesRecipeModelFromJson(Map<String, dynamic> json) =>
    LikesRecipeModel()
      ..id = json['id'] as int
      ..name = json['name'] as String
      ..description = json['description'] as String
      ..ingredients = (json['ingredients'] as List<dynamic>)
          .map((e) => IngredientModel.fromJson(e as Map<String, dynamic>))
          .toList()
      ..likeCount = json['likeCount'] as int
      ..hasUserLiked = json['hasUserLiked'] as bool
      ..createdBy = json['createdBy'] as String
      ..createdDate = DateTime.parse(json['createdDate'] as String);

Map<String, dynamic> _$LikesRecipeModelToJson(LikesRecipeModel instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
      'ingredients': instance.ingredients.map((e) => e.toJson()).toList(),
      'likeCount': instance.likeCount,
      'hasUserLiked': instance.hasUserLiked,
      'createdBy': instance.createdBy,
      'createdDate': instance.createdDate.toIso8601String(),
    };
