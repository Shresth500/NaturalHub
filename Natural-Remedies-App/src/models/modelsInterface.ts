export interface IRemedies {
  id: number;
  name: string;
  remedies: Remedy[];
  description: string;
  benefits: string;
  preparation: string;
  usage: string;
}

export interface Remedy {
  id: number;
  name: string;
}

export interface ITips {
  tipId: number;
  tipName: string;
}

export interface IHealthTips {
  id: number;
  name: string;
  tips: ITips[];
}

export interface ISignUp {
  username: string;
  email: string;
  password: string;
  roles: string[];
}

export interface ILogin {
  email: string;
  password: string;
}

export interface IProducts {
  id: number;
  name: string;
  quantity: number;
  price: number;
  description: string;
  benefits: string;
}

export interface ICarts {
  id: number;
  name: string;
  quantity: number;
  price: number;
}

export interface IOrder {
  id: number;
  products: IOrderItems[];
}

export interface IOrderItems {
  name: string;
  quantity: number;
  price: number;
}

export interface IUserProductCatalog {
  id: string;
  name: string;
  email: string;
  carts: ICarts[];
  order: IOrder[];
}

export interface IAddProduct {
  productId: number;
  quantity: number;
}
