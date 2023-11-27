import 'package:app/common/common_snackbar.dart';
import 'package:app/models/constants/storage_keys.dart';
import 'package:app/models/domain/likes_recipe_model.dart';
import 'package:app/services/recipe_service.dart';
import 'package:get/get.dart';
import 'package:get_storage/get_storage.dart';
import 'package:jwt_decoder/jwt_decoder.dart';

class RecipeDetailsController extends GetxController{
  final recipe = LikesRecipeModel().obs;
  final errors = <String>[""].obs;
  final recipeService = RecipeService();
  var isAdmin = false;
  @override
  onInit() async {
    super.onInit();
    recipe.value = Get.arguments;

    // todo: UserProvider
    var bearerToken = GetStorage().read(tokenKey);
    var decodedToken = JwtDecoder.decode(bearerToken.toString());
    var adminRoleClaim = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    if(adminRoleClaim is List<dynamic>){
      isAdmin = adminRoleClaim.any((element) => element == 'Admin');
    } else if(adminRoleClaim is String){
      isAdmin = adminRoleClaim == "Admin";
    }
  }


  void onLike() async {
    var result = await (recipe.value.hasUserLiked ? recipeService.unlikeRecipe(recipe.value) : recipeService.likeRecipe(recipe.value));
    if(!result.isSuccess){
      CommonSnackbar.show(result.errorMessages!.first);
      return;
    }

    recipe.value.hasUserLiked = !recipe.value.hasUserLiked;
    recipe.refresh();
    CommonSnackbar.show(recipe.value.hasUserLiked ? "Recipe liked" : "Recipe unliked");
  }

  onRecipeDelete() async{
    var result = await recipeService.deleteRecipe(recipe.value);
    if(!result.isSuccess){
      CommonSnackbar.show(result.errorMessages!.first);
      return;
    }

    Get.back(closeOverlays: true);
    CommonSnackbar.show("Deletion successful");
  }
}