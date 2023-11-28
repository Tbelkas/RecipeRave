import 'package:app/bindings/login_binding.dart';
import 'package:app/bindings/recipe_browser_binding.dart';
import 'package:app/bindings/recipe_create_binding.dart';
import 'package:app/bindings/recipe_details_binding.dart';
import 'package:app/bindings/register_binding.dart';
import 'package:app/models/constants/storage_keys.dart';
import 'package:app/ui/recipe_browser/recipe_browser_screen.dart';
import 'package:app/ui/recipe_create/recipe_create_screen.dart';
import 'package:app/ui/recipe_details/recipe_details_screen.dart';
import 'package:app/ui/register/register_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:get/get.dart';
import 'package:get_storage/get_storage.dart';
import 'package:google_fonts/google_fonts.dart';

import 'ui/login/login_screen.dart';

//todo : common input/text theme
void main() async {
  await GetStorage.init();
  // todo: back to login screen on 401
  final bool isLoggedIn = GetStorage().read(tokenKey) != null;

  runApp(MyApp(initialRoute: isLoggedIn ? RecipeBrowserScreen.routePath : LoginScreen.routePath));
  SystemChrome.setSystemUIOverlayStyle(SystemUiOverlayStyle(
    statusBarColor: Colors.blue.shade50,
  ));
}

class MyApp extends StatelessWidget {
  final String initialRoute;

  const MyApp({required this.initialRoute});

  @override
  Widget build(BuildContext context) {
    return GetMaterialApp(
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        textTheme: TextTheme(
            titleLarge: GoogleFonts.montserrat(
              color: Colors.black,
              fontWeight: FontWeight.w500,
              letterSpacing: 2.0,
              fontSize: 30.0,
            ),
            headlineMedium: GoogleFonts.montserrat(
              color: Colors.white,
              letterSpacing: 2.0,
              fontWeight: FontWeight.w500,
              fontSize: 24.0,
            ),
            headlineSmall: GoogleFonts.indieFlower(
              color: Colors.black,
              fontWeight: FontWeight.w500,
              letterSpacing: 2.0,
              fontSize: 16.0,
            ),
            bodySmall: GoogleFonts.lato(color: Colors.black, letterSpacing: 2.0, fontSize: 12.0, fontStyle: FontStyle.italic)),
      ),
      initialRoute: initialRoute,
      getPages: [
        GetPage(name: LoginScreen.routePath, page: () => LoginScreen(), binding: LoginBinding()),
        GetPage(name: RegisterScreen.routePath, page: () => const RegisterScreen(), binding: RegisterBinding()),
        GetPage(name: RecipeBrowserScreen.routePath, page: () => const RecipeBrowserScreen(), binding: RecipeBrowserBinding()),
        GetPage(name: RecipeDetailsScreen.routePath, page: () => RecipeDetailsScreen(), binding: RecipeDetailsBinding()),
        GetPage(name: RecipeCreateScreen.routePath, page: () => const RecipeCreateScreen(), binding: RecipeCreateBinding())
      ],
    );
  }
}
