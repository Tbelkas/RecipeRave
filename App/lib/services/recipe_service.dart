import 'package:app/models/domain/recipe_model.dart';
import 'package:app/models/requests/network_request.dart';
import 'package:app/models/requests/network_request_type.dart';
import 'package:app/models/responses/base/api_data_response.dart';
import 'package:app/services/network_service.dart';
import 'package:app/ui/login/models/login_model.dart';
import 'package:app/ui/recipe_browser/models/recipe_browser_model.dart';

class RecipeService {
  final NetworkService _networkService;

  RecipeService() : _networkService = NetworkService(baseUrl: "http://10.0.2.2:5218/Recipe");

  Future<ApiDataResponse> getRecipes() async{
    var networkRequest = const NetworkRequest(type: NetworkRequestType.GET, path: "/");
    var result = await _networkService.execute<List<RecipeBrowserModel>>(networkRequest);
    return result;
  }

  Future<ApiDataResponse> createRecipe(RecipeModel model) async{
    var networkRequest = const NetworkRequest(type: NetworkRequestType.GET, path: "/");
    var result = await _networkService.execute<List<RecipeBrowserModel>>(networkRequest);
    return result;
  }

  Future<ApiDataResponse> likeRecipe(RecipeModel model) async{
    var networkRequest = const NetworkRequest(type: NetworkRequestType.GET, path: "/");
    var result = await _networkService.execute<List<RecipeBrowserModel>>(networkRequest);
    return result;
  }

  Future<ApiDataResponse> deleteRecipe(RecipeModel model) async{
    var networkRequest = const NetworkRequest(type: NetworkRequestType.GET, path: "/");
    var result = await _networkService.execute<List<RecipeBrowserModel>>(networkRequest);
    return result;
  }
}