import 'package:app/models/constants/colors.dart';
import 'package:app/models/domain/ingredient_model.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class NewIngredientWidget extends StatelessWidget {
  final IngredientModel model;
  final Function(IngredientModel) onDetailsButtonPressed;

  const NewIngredientWidget(this.model, this.onDetailsButtonPressed, {super.key});

  Widget constructInstructionEntry(IngredientModel e) {
    return Text("• ${e.ingredientAmount} grams of ${e.name}", style: const TextStyle(fontSize: 12, fontWeight: FontWeight.w700));
  }

  @override
  Widget build(BuildContext context) {
    return Padding(padding: const EdgeInsets.all(4.0),
        child: Container(padding: const EdgeInsets.all(4.0),
            decoration:
            BoxDecoration(border: Border.all(color: PRIMARY_COLOR, width: 2)),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [

            Text("${model.measurementUnit} ${model.ingredientAmount} ${model.name}"),
              IconButton(onPressed: () => onDetailsButtonPressed(model), icon: const Icon(Icons.delete, color: Colors.red))

          ],),
        ));
  }
}
