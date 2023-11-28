import 'package:app/models/domain/recipe_model.dart';
import 'package:app/models/requests/change_like_status_request.dart';
import 'package:app/models/requests/delete_recipe_request.dart';
import 'package:app/models/requests/network_request.dart';
import 'package:app/models/requests/network_request_type.dart';
import 'package:app/models/responses/base/api_data_response.dart';
import 'package:app/services/network_service.dart';


class RecipeService {
  final NetworkService _networkService;

  RecipeService() : _networkService = NetworkService(baseUrl: "http://10.0.2.2:5218/Recipe");

  Future<ApiDataResponse> getRecipes() async{
    var networkRequest = const NetworkRequest(type: NetworkRequestType.GET, path: "/");
    var result = await _networkService.execute(networkRequest);
    return result;
  }

  Future<ApiDataResponse> createRecipe(RecipeModel model) async{
    var networkRequest = NetworkRequest(type: NetworkRequestType.POST, path: "/", data: model.toJson());
    var result = await _networkService.execute(networkRequest);
    return result;
  }

  Future<ApiDataResponse> likeRecipe(RecipeModel model) async{
    var networkRequest = NetworkRequest(type: NetworkRequestType.PUT, path: "/Like", data: ChangeLikeStatusRequest.fromValues(model.id).toJson());
    var result = await _networkService.execute(networkRequest);
    return result;
  }

  Future<ApiDataResponse> unlikeRecipe(RecipeModel model) async{
    var networkRequest = NetworkRequest(type: NetworkRequestType.DELETE, path: "/Like", data: ChangeLikeStatusRequest.fromValues(model.id).toJson());
    var result = await _networkService.execute(networkRequest);
    return result;
  }

  Future<ApiDataResponse> deleteRecipe(RecipeModel model) async{
    var networkRequest = NetworkRequest(type: NetworkRequestType.DELETE, path: "/", data: DeleteRecipeRequest.fromValues(model.id).toJson());
    var result = await _networkService.execute(networkRequest);
    return result;
  }
}