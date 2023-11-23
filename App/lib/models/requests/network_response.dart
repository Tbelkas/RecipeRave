class NetworkResponse<T>{
  late final T? data;
  List<String>? errors;
  int? responseCode;

  NetworkResponse.result(T this.data, [int? this.responseCode = 200]);

  NetworkResponse.error(List<String> errors, [int? this.responseCode = 400]){
    errors = errors;
  }

  NetworkResponse.generic(String error){
    errors = [error];
    this.responseCode = 500;
  }
}