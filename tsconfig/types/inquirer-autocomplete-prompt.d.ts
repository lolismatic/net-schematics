export declare class AutoCompletePromptModule {
    constructor(questions: any, rl: any, answers: any);
    currentChoices: any;
    firstRender: any;
    selected: any;
    paginator: any;
    close(): void;
    ensureSelectedInRange(): void;
    getQuestion(): any;
    handleSubmitEvents(submit: any): any;
    onKeypress(e: any): void;
    onSubmit(line: any): void;
    render(error: any): void;
    run(): any;
    search(searchTerm: any): any;
    throwParamError(name: any): void;
}
