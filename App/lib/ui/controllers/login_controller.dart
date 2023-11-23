
import 'package:app/models/responses/login_response.dart';
import 'package:app/services/auth_service.dart';
import 'package:app/ui/models/login_model.dart';
import 'package:app/ui/screens/register_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:get/get.dart';
import 'package:get_storage/get_storage.dart';

class LoginController extends GetxController{
  late final AuthService authService;
  final loginModel = LoginModel().obs;

  final userName = ''.obs;
  final password = ''.obs;

  final userNameController = TextEditingController();
  final passwordController = TextEditingController();
  final errors = <String>[""].obs;

  @override
  onInit(){
    super.onInit();

    // todo: DI
    authService = AuthService();
  }

  onSignIn() async{
    loginModel.value.username = userNameController.value.text;
    loginModel.value.password = passwordController.value.text;

    var result = await authService.login(loginModel.value);
    if (!result.isSuccess){
      errors.value = result.errorMessages!;
      return;
    }

    var resultData = LoginResponse.fromJson(result.data);

    // todo: Keys separate file
    // todo: Refresh tokens?
    GetStorage().write('token', resultData.token);
  }

  onRegister() async {
    userName.value = (await Get.toNamed(RegisterScreen.routePath)).toString();
  }
}