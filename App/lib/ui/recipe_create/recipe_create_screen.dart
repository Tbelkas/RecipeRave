import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:app/ui/common_widgets/app_bar/common_app_bar.dart';
import 'package:app/ui/common_widgets/error_message/error_message_widget.dart';
import 'package:app/ui/recipe_create/recipe_create_controller.dart';
import 'package:app/ui/recipe_create/widgets/new_ingredient_list_widget.dart';
import 'package:app/ui/register/register_controller.dart';
import 'package:flutter/material.dart';
import 'package:flutter_quill/flutter_quill.dart';
import 'package:get/get.dart';

class RecipeCreateScreen extends GetView<RecipeCreateController> {
  static const routePath = '/recipeCreate';
  static const _screenTitle = 'Create new recipe';

  const RecipeCreateScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        resizeToAvoidBottomInset: false,
        appBar: const CommonAppBar(_screenTitle),
        body: SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              NewIngredientListWidget(onSave: (ingredients) => {}),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                child: TextField(
                  controller: controller.descriptionTextController,
                  maxLines: 4,

                  decoration: const InputDecoration(border: OutlineInputBorder(), hintText: "Description"),
                ),
              ),
            ],
          ),
        ));
  }
}
