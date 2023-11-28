import 'dart:io';

import 'package:app/common/common_snackbar.dart';
import 'package:app/models/domain/ingredient_model.dart';
import 'package:app/models/domain/recipe_model.dart';
import 'package:app/services/recipe_service.dart';
import 'package:flutter/cupertino.dart';
import 'package:get/get.dart';
import 'package:image_picker/image_picker.dart';
import 'dart:convert';

class RecipeCreateController extends GetxController {
  final ingredients = List<IngredientModel>.empty().obs;
  final image = Rx<File?>(null);
  final nameTextController = TextEditingController();
  final descriptionTextController = TextEditingController();
  final recipeService = RecipeService();


  pickImage() async {
    try {
      final image = await ImagePicker().pickImage(source: ImageSource.gallery);
      this.image.value = File(image!.path);
    } catch(e) {
      CommonSnackbar.show("Image picker failed");
    }
  }

  onInsert() async {
    List<int> imageBytes = image.value!.readAsBytesSync();
    String base64Image = base64Encode(imageBytes);
    var recipeModel = RecipeModel.fromValues(nameTextController.value.text, descriptionTextController.value.text, ingredients, base64Image);
    var result = await recipeService.createRecipe(recipeModel);

    if(!result.isSuccess){
      CommonSnackbar.show(result.errorMessages!.first);
      return;
    }

    Get.back(result: recipeModel);
  }
}
