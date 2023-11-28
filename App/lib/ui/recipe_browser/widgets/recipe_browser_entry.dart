import 'dart:convert';

import 'package:app/models/constants/colors.dart';
import 'package:app/models/domain/ingredient_model.dart';
import 'package:app/models/domain/likes_recipe_model.dart';
import 'package:app/models/domain/recipe_model.dart';
import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:app/ui/common_widgets/recipe/recipe_ingredients_column_widget.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class RecipeBrowserEntry extends StatelessWidget {
  final LikesRecipeModel recipeModel;
  final Function(RecipeModel) onDetailsButtonPressed;

  const RecipeBrowserEntry({super.key, required this.recipeModel, required this.onDetailsButtonPressed});

  Widget constructInstructionEntry(IngredientModel e) {
    return Text("• ${e.ingredientAmount} grams of ${e.name}", style: const TextStyle(fontSize: 12, fontWeight: FontWeight.w700));
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
        padding: const EdgeInsets.all(4.0),
        child: Container(
          padding: const EdgeInsets.all(4.0),
          decoration: BoxDecoration(border: Border.all(color: PRIMARY_COLOR, width: 2)),
          child: Column(
            children: [
              Align(
                alignment: Alignment.topRight,
                child: Text('${recipeModel.createdDate.year}-${recipeModel.createdDate.month}-${recipeModel.createdDate.day} ${recipeModel.createdBy}'),
              ),
              Align(
                alignment: Alignment.topLeft,
                child: Text(recipeModel.name, style: Theme.of(context).textTheme.headlineSmall),
              ),
              Row(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Expanded(
                      flex: 5,
                      child: AspectRatio(
                        aspectRatio: 16 / 9,
                        child: recipeModel.base64Image == null ? Image.asset(
                          'assets/recipe_picture_placeholder.jpg',
                          fit: BoxFit.cover,
                        ) : Image.memory(base64Decode(recipeModel.base64Image!)),
                      )),
                  Expanded(
                      flex: 8,
                      child: Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: RecipeIngredientsColumnWidget(ingredients: recipeModel.ingredients, iterationStopPoint: 5)))
                ],
              ),
              Row(
                children: [
                  Expanded(flex: 2, child: Text(_getLikeText())),
                  Expanded(flex: 2, child: CommonTextButton(text: "See full recipe", onPressed: () => onDetailsButtonPressed(recipeModel))),
                ],
              )
            ],
          ),
        ));
  }

  // todo: constants strings with values inserted into them for better management / p11n
  String _getLikeText(){
    var count = recipeModel.likeCount;
    if(count == 0){
      return "No likes";
    }
    String likeText = '';

    if(recipeModel.hasUserLiked){
      likeText += "You ";
      if(count > 1){

        likeText += "and ${count-1} ${count == 2 ? 'other' : 'others'} ";
      }
    }

    if(!recipeModel.hasUserLiked && count > 0){
      likeText += "$count ";
    }


    likeText += "like it";
    return likeText;
  }
}
