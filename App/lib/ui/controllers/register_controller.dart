import 'dart:developer';

import 'package:app/ui/models/register_model.dart';
import 'package:flutter/cupertino.dart';
import 'package:get/get.dart';

class RegisterController extends GetxController{
  final registerModel = RegisterModel().obs;

  final userName = ''.obs;
  final password = ''.obs;
  final confirmPassword = ''.obs;

  setUserName(userName){
    this.userName.value = userName;
  }

  setPassword(password){
    this.password.value = password;
  }

  setConfirmPassword(confirmPassword){
    this.confirmPassword.value = confirmPassword;
  }


  final userNameController = TextEditingController();
  final passwordController = TextEditingController();
  final confirmPasswordController = TextEditingController();


  get getUsername => registerModel.value.username;
  setUsername(username) {
    registerModel.value.username = username;
  }

  @override
  void onInit() {
    super.onInit();
  }

  onRegister(){
    log('data: ${userNameController.value.text}, $password, $passwordController');
  }

  validateData(){

  }
}