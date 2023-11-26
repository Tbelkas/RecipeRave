import 'package:app/models/constants/colors.dart';
import 'package:app/models/domain/ingredient_model.dart';
import 'package:app/models/domain/recipe_model.dart';
import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:flutter/cupertino.dart';

class RecipeBrowserEntry extends StatelessWidget {
  final RecipeModel recipeModel;
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
          decoration: const BoxDecoration(
            border: Border(
              top: BorderSide(color: PRIMARY_COLOR, width: 2),
              left: BorderSide(color: PRIMARY_COLOR, width: 2),
              right: BorderSide(color: PRIMARY_COLOR, width: 2),
              bottom: BorderSide(color: PRIMARY_COLOR, width: 2),
            ),
          ),
          child: Column(
            children: [
              const Align(
                alignment: Alignment.topRight,
                child: Text('2023-11-25 Babinskas'),
              ),
              Align(
                alignment: Alignment.topLeft,
                child: Text('${recipeModel.name}'),
              ),
              Row(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Expanded(
                      flex: 5,
                      child: AspectRatio(
                        aspectRatio: 16 / 9,
                        child: Image.asset(
                          'assets/recipe_picture_placeholder.jpg',
                          fit: BoxFit.cover,
                        ),
                      )),
                  Expanded(
                      flex: 8,
                      child: Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: Column(
                              mainAxisSize: MainAxisSize.max,
                              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: recipeModel.ingredients.map((e) => constructInstructionEntry(e)).toList())))
                ],
              ),
              Row(
                children: [
                  const Expanded(flex: 2, child: Text("you and 4 other like it")),
                  Expanded(flex: 2, child: CommonTextButton(text: "See full recipe", onPressed: () => onDetailsButtonPressed(recipeModel))),
                ],
              )
            ],
          ),
        ));
  }
}
