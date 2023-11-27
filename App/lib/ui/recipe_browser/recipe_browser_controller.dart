import 'package:app/common/common_snackbar.dart';
import 'package:app/models/domain/likes_recipe_model.dart';
import 'package:app/models/domain/recipe_model.dart';
import 'package:app/services/recipe_service.dart';
import 'package:app/ui/recipe_create/recipe_create_screen.dart';
import 'package:app/ui/recipe_details/recipe_details_screen.dart';
import 'package:get/get.dart';

class RecipeBrowserController extends GetxController{
  var recipes =  List<LikesRecipeModel>.empty().obs;
  final errors = <String>[""].obs;
  final _recipeService = RecipeService();

  @override
  onInit() async {
    super.onInit();
    await _get_recipes();
  }

  onNewRecipe() async{
     Get.toNamed(RecipeCreateScreen.routePath);
  }

  onRecipeDetailsPressed(RecipeModel recipeModel) async{
    await Get.toNamed(RecipeDetailsScreen.routePath, arguments: recipeModel);
    _get_recipes();
    // todo: possible to refresh one instead of the whole list?
    recipes.refresh();
  }

  _get_recipes() async{
    var result = await _recipeService.getRecipes();
    if(!result.isSuccess){
      CommonSnackbar.show(result.errorMessages!.first);
      return;
    }

    final mappedData = (result.data as List).map((e) => LikesRecipeModel.fromJson(e));
    recipes.value = mappedData.toList();
    // todo: display refresh button on fail
  }
}
