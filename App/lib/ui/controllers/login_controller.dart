import 'package:app/ui/models/login_model.dart';
import 'package:app/ui/screens/register_screen.dart';
import 'package:get/get.dart';

class LoginController extends GetxController{
  final _loginModel = LoginModel().obs;
  @override
  void onInit() {
    super.onInit();
  }

  onSignIn(){

  }

  onRegister(){
    Get.toNamed(RegisterScreen.routePath);
  }
}