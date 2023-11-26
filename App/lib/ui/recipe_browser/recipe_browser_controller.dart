import 'dart:developer';

import 'package:app/models/domain/recipe_model.dart';
import 'package:app/services/recipe_service.dart';
import 'package:app/ui/recipe_details/recipe_details_screen.dart';
import 'package:get/get.dart';

class RecipeBrowserController extends GetxController{
  var recipes =  List<RecipeModel>.empty().obs;
  final errors = <String>[""].obs;
  final _recipeService = RecipeService();

  @override
  onInit() async {
    super.onInit();
    log("onInit Recipe browser");
  }

  onNewRecipe() async{
    var result = await _recipeService.getRecipes();
    if(result.isSuccess){
      // todo:
      final mappedData = (result.data as List).map((e) => RecipeModel.fromJson(e));
      recipes.value = mappedData.toList();
    }
  }

  onRecipeDetailsPressed(RecipeModel recipeModel) {
    Get.toNamed(RecipeDetailsScreen.routePath, arguments: recipeModel);
  }

}
