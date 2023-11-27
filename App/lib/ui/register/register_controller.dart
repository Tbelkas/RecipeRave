import 'dart:developer';

import 'package:app/common/common_snackbar.dart';
import 'package:app/services/auth_service.dart';
import 'package:app/ui/register/models/register_model.dart';
import 'package:flutter/cupertino.dart';
import 'package:get/get.dart';

class RegisterController extends GetxController{

  final registerModel = RegisterModel().obs;
  late final AuthService authService;
  final userName = ''.obs;
  final email = ''.obs;
  final password = ''.obs;
  final confirmPassword = ''.obs;

  final userNameController = TextEditingController();
  final emailController = TextEditingController();
  final passwordController = TextEditingController();
  final confirmPasswordController = TextEditingController();

  final formKey = GlobalKey<FormState>();
  @override
  onInit(){
    super.onInit();

    // todo: DI
    authService = AuthService();
  }

  onRegister() async {
    registerModel.value.username = userNameController.value.text;
    registerModel.value.password = passwordController.value.text;
    registerModel.value.confirmPassword = confirmPasswordController.value.text;
    registerModel.value.email = emailController.value.text;

    var result = await authService.register(registerModel.value);
    if (!result.isSuccess){
      CommonSnackbar.show(result.errorMessages!.first);
      return;
    }

    Get.back(result: registerModel.value.username);
  }

  validateData(){

  }
}