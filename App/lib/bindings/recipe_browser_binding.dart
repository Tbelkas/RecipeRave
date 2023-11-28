import 'package:app/ui/recipe_browser/recipe_browser_controller.dart';
import 'package:get/get.dart';



class RecipeBrowserBinding implements Bindings{
  @override
  void dependencies() {
    Get.put(RecipeBrowserController());
  }
}