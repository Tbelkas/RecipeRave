import 'package:app/ui/common_widgets/app_bar/common_app_bar.dart';
import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:app/ui/recipe_create/recipe_create_controller.dart';
import 'package:app/ui/recipe_create/widgets/new_ingredient_list_widget.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class RecipeCreateScreen extends GetView<RecipeCreateController> {
  static const routePath = '/recipeCreate';
  static const _screenTitle = 'Create new recipe';

  const RecipeCreateScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        resizeToAvoidBottomInset: false,
        appBar: const CommonAppBar(_screenTitle),
        body: SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                child: TextField(
                  controller: controller.nameTextController,
                  decoration: const InputDecoration(border: OutlineInputBorder(), labelText: "Name"),
                ),
              ),
              NewIngredientListWidget(onIngredientChange: (ingredients) => controller.ingredients.value = ingredients),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                child: TextField(
                  controller: controller.descriptionTextController,
                  maxLines: 4,
                  decoration: const InputDecoration(border: OutlineInputBorder(), labelText: "Description"),
                ),
              ),
              Obx(() => controller.image.value != null
                  ? GestureDetector(onTap: controller.pickImage, child: Image.file(controller.image.value!, width: 200))
                  : CommonTextButton(text: 'Add image', onPressed: controller.pickImage)),
              Padding(padding: const EdgeInsets.only(top: 16, bottom: 8), child: CommonTextButton(text: "Insert", onPressed: controller.onInsert))
            ],
          ),
        ));
  }
}
