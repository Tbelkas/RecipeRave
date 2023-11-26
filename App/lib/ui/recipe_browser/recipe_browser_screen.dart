import 'package:app/ui/common_widgets/app_bar/common_app_bar.dart';
import 'package:app/ui/recipe_browser/recipe_browser_controller.dart';
import 'package:app/ui/recipe_browser/widgets/recipe_browser_entry.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class RecipeBrowserScreen extends GetView<RecipeBrowserController> {
  static const routePath = '/recipeBrowser';
  static const _screenTitle = 'Recipe browser';

  const RecipeBrowserScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: const CommonAppBar(_screenTitle, shouldDisplayLogout: true),
        floatingActionButton: FloatingActionButton(
          onPressed: controller.onNewRecipe,
          tooltip: 'Add new recipe',
          child: const Icon(Icons.add),
        ),
        body: SafeArea(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Expanded(
          child: Obx(() =>  ListView.builder(
            shrinkWrap: true,
            physics: const ScrollPhysics(),
            padding: const EdgeInsets.all(8),
            itemCount: controller.recipes.length,
            itemBuilder: (BuildContext context, int index) => RecipeBrowserEntry(recipeModel: controller.recipes.elementAt(index), onDetailsButtonPressed: (recipeModel) => controller.onRecipeDetailsPressed(recipeModel))
          )),
          )
        ],
      ),
    ));
  }
}
