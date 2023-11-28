import 'package:app/ui/login/login_controller.dart';
import 'package:app/ui/recipe_details/recipe_details_controller.dart';
import 'package:get/get.dart';

class LoginBinding implements Bindings{
  @override
  void dependencies() {
    Get.put(LoginController());
  }
}