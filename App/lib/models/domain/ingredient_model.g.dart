// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ingredient_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

IngredientModel _$IngredientModelFromJson(Map<String, dynamic> json) =>
    IngredientModel()
      ..name = json['name'] as String
      ..ingredientAmount = (json['ingredientAmount'] as num).toDouble()
      ..measurementUnit = json['measurementUnit'] as int;

Map<String, dynamic> _$IngredientModelToJson(IngredientModel instance) =>
    <String, dynamic>{
      'name': instance.name,
      'ingredientAmount': instance.ingredientAmount,
      'measurementUnit': instance.measurementUnit,
    };
