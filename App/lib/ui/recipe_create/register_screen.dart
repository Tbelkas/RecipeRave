import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:app/ui/common_widgets/app_bar/common_app_bar.dart';
import 'package:app/ui/common_widgets/error_message/error_message_widget.dart';
import 'package:app/ui/register/register_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class RecipeCreateScreen extends GetView<RegisterController> {
  static const routePath = '/recipeCreate';
  static const _screenTitle = 'Create new recipe';

  const RecipeCreateScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        resizeToAvoidBottomInset: false,
        appBar: const CommonAppBar(_screenTitle),
        body: SafeArea(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Image.asset("assets/logo.png"),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
            child: Obx(() => ErrorMessageWidget(
              errors: controller.errors.value,
            ),
            )
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: TextField(
              controller: controller.userNameController,
              decoration: const InputDecoration(
                  border: OutlineInputBorder(), hintText: "Username"),
            ),
          ),


          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: TextField(
              controller: controller.emailController,
              decoration: const InputDecoration(
                  border: OutlineInputBorder(), hintText: "Email"),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: TextField(
              controller: controller.passwordController,
              decoration: const InputDecoration(
                  border: OutlineInputBorder(), hintText: "Password"),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: TextField(
              controller: controller.confirmPasswordController,
              decoration: const InputDecoration(
                  border: OutlineInputBorder(), hintText: "Confirm password"),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: CommonTextButton(
              text: 'Register',
              onPressed: controller.onRegister,
            ),
          )
        ],
      ),
    ));
  }
}
