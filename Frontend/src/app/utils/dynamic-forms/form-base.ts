export class FormBase<T> {
    value: T;
    key: string;
    label: string;
    required: boolean;
    order: number;
    controlType: string;
    textPrefix: string;
    textValue: string;
    metaInfo: string;

    constructor(options: {
        value?: T,
        key?: string,
        label?: string,
        required?: boolean,
        order?: number,
        controlType?: string,
        textPrefix?: string,
        textValue?: string,
        metaInfo?: string
      } = {}) {
      this.value = options.value;
      this.key = options.key || '';
      this.label = options.label || '';
      this.required = !!options.required;
      this.order = options.order === undefined ? 1 : options.order;
      this.controlType = options.controlType || '';
      this.textPrefix = options.textPrefix || '';
      this.textValue = options.textValue || '';
      this.metaInfo = options.metaInfo || '';
    }
  }
