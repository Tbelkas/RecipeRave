import 'package:app/ui/common_widgets/app_bar/common_app_bar.dart';
import 'package:app/ui/common_widgets/recipe/recipe_ingredients_column_widget.dart';
import 'package:app/ui/recipe_details/recipe_details_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class RecipeDetailsScreen extends GetView<RecipeDetailsController> {
  static const routePath = '/recipeDetails';

  const RecipeDetailsScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: CommonAppBar(controller.recipe.name),
      resizeToAvoidBottomInset: false,
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 12),
        child: Row(
          children: [
            FloatingActionButton(
              heroTag: "Like",
              onPressed: () {},
              backgroundColor: Colors.green,
              child: const Icon(Icons.add_comment), // todo: Like
            ),
            const Spacer(),
            FloatingActionButton(
              heroTag: "Delete",
              onPressed: () {},
              backgroundColor: Colors.red,
              child: const Icon(Icons.remove_circle),
            ),
          ],
        ),
      ),
      body: SafeArea(
          child: Padding(
              padding: const EdgeInsets.only(bottom: 100),
              child: SingleChildScrollView(
                  child: Column(
                children: [
                  Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 64, vertical: 12),
                      child: AspectRatio(
                          aspectRatio: 16 / 9,
                          child: Image.asset(
                            'assets/recipe_picture_placeholder.jpg',
                            fit: BoxFit.cover,
                          ))),
                  Padding(
                    padding: const EdgeInsets.symmetric(vertical: 8, horizontal: 32),
                    child: Text(controller.recipe.description),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(vertical: 8, horizontal: 32),
                    child: Text("Ingredients", style: Theme.of(context).textTheme.headlineLarge),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(vertical: 8, horizontal: 32),
                    child: RecipeIngredientsColumnWidget(ingredients: controller.recipe.ingredients),
                  )
                ],
              )))),
    );
  }
}
