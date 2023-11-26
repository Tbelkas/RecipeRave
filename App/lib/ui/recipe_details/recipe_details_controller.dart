import 'dart:developer';

import 'package:app/models/domain/recipe_model.dart';
import 'package:app/services/recipe_service.dart';
import 'package:get/get.dart';

class RecipeDetailsController extends GetxController{
  late RecipeModel recipe;
  final errors = <String>[""].obs;
  final _recipeService = RecipeService();
  @override
  onInit() async {
    super.onInit();
    recipe = Get.arguments;
  }

  onRecipeLike(){

  }

  onRecipeDelete() {

  }
}