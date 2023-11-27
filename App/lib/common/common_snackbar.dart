import 'package:flutter/animation.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class CommonSnackbar {
  static SnackbarController show(String title) => Get.snackbar('Recipe rave', title,
      snackPosition: SnackPosition.BOTTOM, reverseAnimationCurve: Curves.easeOut, duration: const Duration(seconds: 2), borderRadius: 10, maxWidth: 200, icon: const Icon(Icons.add_alert));
}
