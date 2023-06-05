import { issueStatus } from "../shared/enum-list";

export class Application {
  public applicationId?: number;

  public tradeId?: number;
  public jobTitle?: string;

  public applicantId?: number;
  public passsportNo?: string;

  public agencyId?: number;
  public name?: string;

  public applicationDate?: Date;
  public status?: issueStatus;



}
