
import 'package:app/common/common_snackbar.dart';
import 'package:app/models/constants/storage_keys.dart';
import 'package:app/models/responses/login_response.dart';
import 'package:app/services/auth_service.dart';
import 'package:app/ui/login/models/login_model.dart';
import 'package:app/ui/recipe_browser/recipe_browser_screen.dart';
import 'package:app/ui/register/register_screen.dart';
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
  final formKey = GlobalKey<FormState>();

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
      CommonSnackbar.show(result.errorMessages!.first);
      return;
    }

    var resultData = LoginResponse.fromJson(result.data);

    // todo: Refresh tokens?
    GetStorage().write(tokenKey, resultData.token);

    Get.offAllNamed(RecipeBrowserScreen.routePath);
  }

  onRegister() async {
    var returnedValue = (await Get.toNamed(RegisterScreen.routePath));
    if(returnedValue != null){
      userName.value = returnedValue.toString();
      CommonSnackbar.show("Registration successful");
    }
  }
}