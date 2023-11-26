import 'package:app/models/domain/ingredient_model.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class RecipeIngredientsColumnWidget extends StatelessWidget {
  final List<IngredientModel> ingredients;

  const RecipeIngredientsColumnWidget({super.key, required this.ingredients});

  Widget constructInstructionEntry(IngredientModel e, BuildContext context) {
    return Text("• ${e.ingredientAmount} grams of ${e.name}", style: Theme.of(context).textTheme.bodySmall);
  }

  @override
  Widget build(BuildContext context) {
    return Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: ingredients.map((e) => constructInstructionEntry(e, context)).toList());
  }
}
