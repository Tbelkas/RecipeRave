import 'package:app/ui/recipe_create/recipe_create_controller.dart';
import 'package:get/get.dart';

class RecipeCreateBinding implements Bindings{
  @override
  void dependencies() {
    Get.put(RecipeCreateController());
  }
}