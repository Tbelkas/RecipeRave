import 'package:app/models/constants/colors.dart';
import 'package:app/models/domain/ingredient_model.dart';
import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:app/ui/recipe_create/widgets/new_ingredient_widget.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class NewIngredientListWidget extends StatefulWidget {
  final ingredients = List<IngredientModel>.empty(growable: true);
  final Function(List<IngredientModel>) onIngredientChange;
  final List<String> list = <String>['One', 'Two', 'Three', 'Four']; // todo mesurements
  final newIngredientTextController = TextEditingController();
  final newAmountController = TextEditingController();
  var selectedMeasurement = 0;

  NewIngredientListWidget({super.key, required this.onIngredientChange});

  @override
  State<StatefulWidget> createState() => _NewIngredientListState();
}

class _NewIngredientListState extends State<NewIngredientListWidget> {
  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return Padding(
        padding: const EdgeInsets.all(8.0),
        child: Container(
            padding: const EdgeInsets.all(8.0),
            decoration: BoxDecoration(border: Border.all(color: PRIMARY_COLOR, width: 2)),
            child: Column(
              children: [
                Column(children: widget.ingredients.map((e) => NewIngredientWidget(e, (e)
                {
                  widget.ingredients.remove(e);
                  widget.onIngredientChange(widget.ingredients);
                  setState((){});

                }
                )).toList()),
                Form(
                  key: _formKey,
                  child: Column(
                    children: [
                      TextFormField(
                          validator: (value) {
                            if (value == null || value.isEmpty) {
                              return 'Specify the ingredient';
                            }
                            return null;
                          },
                          controller: widget.newIngredientTextController,
                          decoration: const InputDecoration(contentPadding: EdgeInsets.only(left: 8), hintText: "Ingredient", helperText: "")),
                      Row(
                        children: [
                          Expanded(
                              flex: 2,
                              child: Padding(
                                  padding: EdgeInsets.only(bottom: 34),
                                  child: DropdownMenu<int>(
                                    inputDecorationTheme: const InputDecorationTheme(contentPadding: EdgeInsets.only(left: 8)),
                                    initialSelection: 0,
                                    onSelected: (int? value) {
                                      widget.selectedMeasurement = value!;
                                    },
                                    dropdownMenuEntries: widget.list.asMap().entries.map<DropdownMenuEntry<int>>((entry) {
                                      return DropdownMenuEntry<int>(value: entry.key, label: entry.value);
                                    }).toList(),
                                  ))),
                          Expanded(
                            flex: 3,
                            child: TextFormField(
                                validator: (value) {
                                  if (value == null || value.isEmpty) {
                                    return 'Specify the amount';
                                  }
                                  return null;
                                },
                                keyboardType: TextInputType.number,
                                controller: widget.newAmountController,
                                decoration: const InputDecoration(contentPadding: EdgeInsets.only(left: 8), hintText: "Amount", helperText: "")),
                          ),
                        ],
                      ),
                      CommonTextButton(
                          text: "Insert",
                          onPressed: () {
                            if (_formKey.currentState!.validate()) {
                              _createNewIngredient();
                            }
                          },
                          height: 40)
                    ],
                  ),
                )
              ],
            )));
  }

  _createNewIngredient() {
    var newIngredient = IngredientModel.fromValues(widget.newIngredientTextController.text, double.parse(widget.newAmountController.text), widget.selectedMeasurement);
    widget.ingredients.add(newIngredient);
    widget.onIngredientChange(widget.ingredients);
    setState((){}); // todo: fix
  }
}
