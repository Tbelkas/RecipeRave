import 'package:app/models/constants/colors.dart';
import 'package:app/ui/common_widgets/app_bar/common_app_bar.dart';
import 'package:app/ui/common_widgets/recipe/recipe_ingredients_column_widget.dart';
import 'package:app/ui/recipe_details/recipe_details_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class RecipeDetailsScreen extends GetView<RecipeDetailsController> {
  static const routePath = '/recipeDetails';

  RecipeDetailsScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: CommonAppBar(controller.recipe.value.name),
      resizeToAvoidBottomInset: false,
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 12),
        child: Row(
          children: [
            Obx(() =>  FloatingActionButton(
              heroTag: "Like",
              onPressed: controller.onLike,
              backgroundColor: controller.recipe.value.hasUserLiked ? Colors.red[200] : Colors.green[200],
              child: Icon(controller.recipe.value.hasUserLiked ? Icons.remove_circle : Icons.add_comment), // todo: Like
            )),
            const Spacer(),
            if(controller.isAdmin) FloatingActionButton(
              heroTag: "Delete",
              onPressed: deleteDialogConfirmation,
              backgroundColor: Colors.red,
              child: const Icon(Icons.remove_circle),
            )
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
                    child: Text(controller.recipe.value.description),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(vertical: 8, horizontal: 32),
                    child: Text("Ingredients", style: Theme.of(context).textTheme.headlineLarge),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(vertical: 8, horizontal: 32),
                    child: RecipeIngredientsColumnWidget(ingredients: controller.recipe.value.ingredients),
                  )
                ],
              )))),
    );
  }

  // https://stackoverflow.com/questions/72860382/custom-widget-for-getx-dialog
  deleteDialogConfirmation(){
    return Get.dialog(
      Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 40),
            child: Container(
              decoration: const BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.all(
                  Radius.circular(20),
                ),
              ),
              child: Padding(
                padding: const EdgeInsets.all(20.0),
                child: Material(
                  child: Column(
                    children: [
                      const SizedBox(height: 10),
                      const Text(
                        "Confirm deletion",
                        textAlign: TextAlign.center,
                      ),
                      const SizedBox(height: 15),
                      Text(
                        "This will delete ${controller.recipe.value.name}",
                        textAlign: TextAlign.center,
                      ),
                      const SizedBox(height: 20),
                      //Buttons
                      Row(
                        children: [
                          Expanded(
                            child: ElevatedButton(
                              child: const Text(
                                'Confirm',
                              ),
                              style: ElevatedButton.styleFrom(
                                minimumSize: const Size(0, 45),
                                backgroundColor: Colors.red,
                                foregroundColor: const Color(0xFFFFFFFF),
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(8),
                                ),
                              ),
                              onPressed: controller.onRecipeDelete,
                            ),
                          )
                        ],
                      ),
                    ],
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
