import 'dart:math';

import 'package:app/models/domain/ingredient_model.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class RecipeIngredientsColumnWidget extends StatelessWidget {
  final List<IngredientModel> ingredients;
  // todo : naming
  final int? iterationStopPoint;
  const RecipeIngredientsColumnWidget({super.key, required this.ingredients, this.iterationStopPoint});

  List<Text> constructInstructionEntry(BuildContext context) {
    var stopBy = iterationStopPoint != null ? min(ingredients.length, iterationStopPoint!) : ingredients.length;
    var textList = List<Text>.empty(growable: true);
    for(int i = 0; i< stopBy; i++){
      var e = ingredients[i];
      textList.add(Text("• ${e.ingredientAmount} grams of ${e.name}", style: Theme.of(context).textTheme.bodySmall));
    }

    if(iterationStopPoint != null && iterationStopPoint! < ingredients.length){
      textList.add(Text("• ...", style: Theme.of(context).textTheme.bodySmall));

    }

    return textList;
  }

  @override
  Widget build(BuildContext context) {
    return Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: constructInstructionEntry(context));
  }
}
