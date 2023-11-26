import 'package:app/ui/recipe_details/recipe_details_controller.dart';
import 'package:get/get.dart';

class RecipeDetailsBinding implements Bindings{
  @override
  void dependencies() {
    Get.put(RecipeDetailsController());
  }
}