export interface UserDTO {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    role: string;
    // Add other properties as needed
  }
  
  export class CreateUserDTO {
    firstName: string;
    lastName: string;
    email: string;
    password: string; // If required for creating a user
    role: string;
  
    constructor(firstName: string, lastName: string, email: string, password: string, role: string) {
      this.firstName = firstName;
      this.lastName = lastName;
      this.email = email;
      this.password = password;
      this.role = role;
    }
  }
  
  export class UpdateUserDTO {
    firstName?: string;
    lastName?: string;
    email?: string;
    role?: string;
  
    constructor(firstName?: string, lastName?: string, email?: string, role?: string) {
      this.firstName = firstName;
      this.lastName = lastName;
      this.email = email;
      this.role = role;
    }
}