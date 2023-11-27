import 'package:app/models/domain/ingredient_model.dart';
import 'package:flutter/cupertino.dart';
import 'package:get/get.dart';

class RecipeCreateController extends GetxController{
  final ingredients = List<IngredientModel>.empty().obs;

  final descriptionTextController = TextEditingController();
  @override
  onInit(){
    super.onInit();

  }

  onRegister() async {
    // registerModel.value.username = userNameController.value.text;
    // registerModel.value.password = passwordController.value.text;
    // registerModel.value.confirmPassword = confirmPasswordController.value.text;
    // registerModel.value.email = confirmPasswordController.value.text;

  }

}